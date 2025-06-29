import { ApplicationStore } from "./slices/app";
import { MasterDataStore } from "./slices/master-data";
import { UserStore } from "./slices/user";

export default interface ApplicationState {
    user: UserStore;
    app: ApplicationStore;
    masterData: MasterDataStore;
}