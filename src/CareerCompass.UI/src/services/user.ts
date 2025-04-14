import { DataServiceResponse } from "../models/http";
import { UserModel } from "../models/user";
import { userHttpService as http } from "./base/baseHttpService";

async function getUserInfo(): Promise<DataServiceResponse<UserModel>> {
  return http.get('/');
}

export { getUserInfo };