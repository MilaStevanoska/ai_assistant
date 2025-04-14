import { UserModel } from "../../models/user";

export interface DashboardProps {
    user: UserModel;

    signOut: () => void;
}