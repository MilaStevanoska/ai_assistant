import { EnumModel, IOption, SchoolYear } from "../../../models/user";

export interface MasterDataStore {
    firstName: string;
    lastName: string;
    fieldOfStudy: string | null;
    skills: EnumModel[];
    areasOfInterest: EnumModel[];
    careerGoal: EnumModel | null;
    schoolYears: SchoolYear[];

    skillsOptions: IOption<number>[];
    areasOfInterestOptions: IOption<number>[];
    subjectOptions: IOption<number>[];
    careerGoalOptions: IOption<number>[];
}

export const initialState: MasterDataStore = {
    firstName : "",
    lastName: "",
    fieldOfStudy: null,
    skills: [],
    areasOfInterest: [],
    careerGoal: null,
    schoolYears: [],

    skillsOptions: [],
    areasOfInterestOptions: [],
    subjectOptions: [],
    careerGoalOptions: [],
};