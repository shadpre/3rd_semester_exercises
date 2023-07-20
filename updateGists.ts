import { Octokit } from "@octokit/rest";
import { RestEndpointMethodTypes } from "@octokit/plugin-rest-endpoint-methods";
import fetch from 'cross-fetch';

// Your GitHub personal access token
const token = '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';

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
async function createOrUpdateGist(filename: string, content: string): Promise<string | undefined> {
    try {
        // Create a gist
        const response = await octokit.gists.create({
            public: true,
            files: {
                [filename]: {
                    content: content
                }
            }
        });
        console.log(`Created gist for ${filename}`);
        return response.data.html_url
    } catch (error) {
        console.error(`Error creating gist for ${filename}: ${error}`);
    }
}

// Function to recursively get all README.md files in a repository
async function getReadmeFiles(path = ''): Promise<void> {
    try {
        const response = await octokit.repos.getContent({
            owner,
            repo,
            path,
        });

        const files = response.data as RestEndpointMethodTypes["repos"]["getContent"]["response"]["data"];

        if (Array.isArray(files)) {
            for (const file of files) {
                if (file.type === 'dir') {
                    // If the file is a directory, recursively search inside it
                    await getReadmeFiles(file.path);
                } else if (file.name === 'README.md') {
                    // If the file is a README.md file, create a gist with its content
                    const readmeContentResponse = await octokit.repos.getContent({
                        owner,
                        repo,
                        path: file.path,
                    });

                    const readmeFile = readmeContentResponse.data as RestEndpointMethodTypes["repos"]["getContent"]["response"]["data"];

                    if ('content' in readmeFile) {
                        const content = Buffer.from(readmeFile.content, 'base64').toString('utf8');
                        let url = await createOrUpdateGist(file.name, content);
                        data.push({
                            url: url,
                            path: file.path
                        })
                    }
                }
            }
        }
    } catch (error) {
        console.error(`Error getting content of ${path}: ${error}`);
    }
}

// Get all README.md files in the repository and create gists for them
getReadmeFiles().then(res => {
    console.log(data);
})
