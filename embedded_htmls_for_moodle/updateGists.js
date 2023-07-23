"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var rest_1 = require("@octokit/rest");
var cross_fetch_1 = require("cross-fetch");
var lookup_1 = require("./lookup");
var owner = 'uldahlalex';
var repo = '3rd_semester_exercises';
// Initialize Octokit
var octokit = new rest_1.Octokit({
    request: {
        fetch: cross_fetch_1.default
    },
    auth: process.env.PATOKEN,
});
// Function to create or update a gist
function myGistUpdateFunction(gistId, content) {
    return __awaiter(this, void 0, void 0, function () {
        var response, error_1;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, octokit.gists.update({
                            gist_id: gistId,
                            files: {
                                'README.md': {
                                    content: content
                                }
                            }
                        })];
                case 1:
                    response = _a.sent();
                    console.log("Created gist");
                    return [2 /*return*/, response.data.html_url];
                case 2:
                    error_1 = _a.sent();
                    console.error("Error creating gist for ".concat(gistId, ": ").concat(error_1));
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
// Function to recursively get all README.md files in a repository
function getReadmeFiles() {
    return __awaiter(this, void 0, void 0, function () {
        var _i, values_1, pair, readmeContentResponse, readmeFile, content, gistId, error_2;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 6, , 7]);
                    _i = 0, values_1 = lookup_1.values;
                    _a.label = 1;
                case 1:
                    if (!(_i < values_1.length)) return [3 /*break*/, 5];
                    pair = values_1[_i];
                    return [4 /*yield*/, octokit.repos.getContent({
                            owner: owner,
                            repo: repo,
                            path: pair.path,
                        })];
                case 2:
                    readmeContentResponse = _a.sent();
                    readmeFile = readmeContentResponse.data;
                    if (!('content' in readmeFile)) return [3 /*break*/, 4];
                    content = Buffer.from(readmeFile.content, 'base64').toString('utf8');
                    gistId = getGistId(pair.url);
                    return [4 /*yield*/, myGistUpdateFunction(gistId, content)];
                case 3:
                    _a.sent();
                    _a.label = 4;
                case 4:
                    _i++;
                    return [3 /*break*/, 1];
                case 5: return [3 /*break*/, 7];
                case 6:
                    error_2 = _a.sent();
                    console.error("Error getting content of ".concat(error_2));
                    return [3 /*break*/, 7];
                case 7: return [2 /*return*/];
            }
        });
    });
}
// Get all README.md files in the repository and create gists for them
getReadmeFiles().then(function (res) {
    console.log('done');
});
function getGistId(url) {
    var parts = url.split('/');
    return parts[parts.length - 1];
}
