import { UserModel } from "../../models/user";

export interface PublicRouteProps {
    children: any;
    user: UserModel;
    isAppInitialized: boolean;
}