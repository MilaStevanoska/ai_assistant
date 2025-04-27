import { DataServiceResponse } from "../models/http";
import { MasterData } from "../models/master-data";
import { IOption } from "../models/user";
import { masterDataHttpService as http } from "./base/baseHttpService";

http.setHeaderValue("Access-Control-Allow-Origin", "https://localhost:7172");

async function getMasterData(): Promise<DataServiceResponse<MasterData>> {
  return http.get("/");
}
async function getSkillsOptions(): Promise<DataServiceResponse<IOption<number>[]>> {
  return http.get("/skills-options");
}
async function getAreasOfInterestOptions(): Promise<DataServiceResponse<IOption<number>[]>> {
  return http.get("/areas-of-interest-options");
}
async function getSubjectOptions(): Promise<DataServiceResponse<IOption<number>[]>> {
  return http.get("/subject-options");
}
async function getCareerGoalOptions(): Promise<DataServiceResponse<IOption<number>[]>> {
  return http.get('/career-goal-options');
}
async function updateMasterData(model: MasterData): Promise<DataServiceResponse> {
  return http.post('/save', model);
}

export { getMasterData, getSkillsOptions, getAreasOfInterestOptions, getSubjectOptions, getCareerGoalOptions, updateMasterData };
