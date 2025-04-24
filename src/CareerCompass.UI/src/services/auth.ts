import { LoginModel, RegisterModel } from "../models/auth";
import { DataServiceResponse } from "../models/http";
import { UserModel } from "../models/user";
import { authHttpService as http } from "./base/BaseHttpService";

http.setHeaderValue("Access-Control-Allow-Origin", "https://localhost:7172");

async function signIn(model: LoginModel): Promise<DataServiceResponse> {
  return http.post('/signin', model);
}

async function register(model: RegisterModel): Promise<DataServiceResponse> {
  return http.post('/register', model);
}

async function signOut(): Promise<DataServiceResponse<UserModel>> {
    return http.post('/signout');
}

export { signIn, signOut, register };