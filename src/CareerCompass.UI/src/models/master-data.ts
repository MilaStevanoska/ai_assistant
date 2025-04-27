import { EnumModel, SchoolYear } from "./user";

export interface MasterData {
    firstName: string;
    lastName: string;
    fieldOfStudy: string | null;
    skills: EnumModel[];
    areasOfInterest: EnumModel[];
    careerGoal: EnumModel | null;
    schoolYears: SchoolYear[];
}