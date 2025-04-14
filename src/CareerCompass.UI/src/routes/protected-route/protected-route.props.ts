import { UserModel } from "../../models/user";

export interface ProtectedRouteProps {
    children: any;
    user: UserModel;
    allowedPaths: string[];
    isAppInitialized: boolean;
}