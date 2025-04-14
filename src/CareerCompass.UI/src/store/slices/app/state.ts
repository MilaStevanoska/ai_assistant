export interface ApplicationStore {
    isInitialized: boolean;
}

export const initialState: ApplicationStore = {
    isInitialized: false
};