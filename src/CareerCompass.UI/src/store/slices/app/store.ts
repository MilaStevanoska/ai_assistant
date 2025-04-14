import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { ApplicationStore, initialState } from "./state";

const slice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setInitialized: (state: ApplicationStore, { payload }: PayloadAction<boolean>) => {
            state.isInitialized = payload;
        }
    }
});

export const { setInitialized } = slice.actions;
export default slice;