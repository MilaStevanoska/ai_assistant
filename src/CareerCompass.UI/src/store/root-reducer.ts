import { Reducer } from "redux";
import ApplicationState from "./application-state";
import { UserReducer } from "./slices/user";
import { ApplicationReducer } from "./slices/app";

type Reducers = Record<keyof Omit<ApplicationState, 'router'>, Reducer<any>>;

const reducers: Reducers = {
  user: UserReducer,
  app: ApplicationReducer
};

export { reducers };