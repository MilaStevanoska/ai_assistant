import { DataServiceResponse } from "../models/http";
import { UserModel } from "../models/user";
import { userHttpService as http } from "./base/baseHttpService";

http.setHeaderValue("Access-Control-Allow-Origin", "https://localhost:7172");

async function getUserInfo(): Promise<DataServiceResponse<UserModel>> {
  return http.get('/');
}

export { getUserInfo };