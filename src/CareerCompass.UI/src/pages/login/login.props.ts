import { NavigateFunction } from "react-router";
import { LoginModel } from "../../models/auth";

export interface LoginProps {
    authenticateUser: (model: LoginModel, navigate: NavigateFunction) => void;
}