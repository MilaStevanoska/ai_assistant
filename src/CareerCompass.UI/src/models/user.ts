export interface UserModel {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    isAuthenticated: boolean;
}
export interface EnumModel {
    name: string;
    value: number;
    displayName: string | null;
}
export interface IOption<T> {
    value: T;
    label: string;
    name: string;
}
export interface SchoolYear {
    year: SchoolYearEnum;
    subjects: EnumModel[];
    grades: Grades;
}
export interface Grades {
    [subject: string]: number;
}
export enum SchoolYearEnum {
    None = 0,
    First = 1,
    Second = 2,
    Third = 3,
    Fourth = 4
}