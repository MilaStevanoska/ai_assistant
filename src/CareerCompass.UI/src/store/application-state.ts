import { ApplicationStore } from "./slices/app";
import { UserStore } from "./slices/user";

export default interface ApplicationState {
    user: UserStore;
    app: ApplicationStore;
}