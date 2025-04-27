import { Reducer } from "redux";
import ApplicationState from "./application-state";
import { UserReducer } from "./slices/user";
import { ApplicationReducer } from "./slices/app";
import { MasterDataReducer } from "./slices/master-data";

type Reducers = Record<keyof Omit<ApplicationState, 'router'>, Reducer<any>>;

const reducers: Reducers = {
  user: UserReducer,
  app: ApplicationReducer,
  masterData: MasterDataReducer
};

export { reducers };