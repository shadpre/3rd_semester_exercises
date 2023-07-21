import {Octokit} from "@octokit/rest";
import {RestEndpointMethodTypes} from "@octokit/plugin-rest-endpoint-methods";
import fetch from 'cross-fetch';
import {values} from "./lookup";
import {token} from './token';

// The owner of the repository and the repository name
const owner = 'uldahlalex';
const repo = '3rd_semester_exercises';

// Initialize Octokit
const octokit = new Octokit({
    request: {
        fetch: fetch
    },
    auth: token,
});

class DataBlueprint {
    url?: string;
    path?: string;
}

let data: DataBlueprint[] = []

// Function to create or update a gist
async function myGistUpdateFunction(gistId: string, content: string): Promise<string | undefined> {
    try {
        // Create a gist
        const response = await octokit.gists.update({
            gist_id: gistId,
            files: {
               'README.md': {
                    content: content
                }
            }
        });


        console.log(`Created gist`);
        return response.data.html_url
    } catch (error) {
        //console.error(`Error creating gist for ${filename}: ${error}`);
    }
}

// Function to recursively get all README.md files in a repository
async function getReadmeFiles(): Promise<void> {
    try {


        for (const pair of values) {
            const readmeContentResponse = await octokit.repos.getContent({
                owner,
                repo,
                path: pair.path,
            });

            const readmeFile = readmeContentResponse.data as RestEndpointMethodTypes["repos"]["getContent"]["response"]["data"];

            if ('content' in readmeFile) {
                const content = Buffer.from(readmeFile.content, 'base64').toString('utf8');
                var gistId = getGistId(pair.url);
                let url = await myGistUpdateFunction(gistId, content);
                data.push({
                   /* url: url,
                    path: pair.path*/
                })


            }
        }


    } catch (error) {
        console.error(`Error getting content of ${error}`);
    }
}

// Get all README.md files in the repository and create gists for them
getReadmeFiles().then(res => {
    console.log(data);
})
function getGistId(url: string) {
    const parts = url.split('/');
    return parts[parts.length - 1];
}