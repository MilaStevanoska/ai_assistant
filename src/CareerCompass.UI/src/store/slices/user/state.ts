export interface UserStore {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    isAuthenticated: boolean;
}

export const initialState: UserStore = {
    id: 0,
    firstName: '',
    lastName: '',
    email: 'filipbosevski1234@gmail.com',
    isAuthenticated: false
};