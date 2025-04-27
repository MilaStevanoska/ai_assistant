import { NavigateFunction } from "react-router";
import { RegisterModel } from "../../models/auth";

export interface RegisterProps {
    registerUser: (model: RegisterModel, navigate: NavigateFunction) => void;
}