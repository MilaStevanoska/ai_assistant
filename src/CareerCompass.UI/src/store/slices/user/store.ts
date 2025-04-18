import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { initialState, UserStore } from "./state";
import { UserModel } from "../../../models/user";
import { AsyncAppThunk } from "../../app-thunk";
import { LoginModel, RegisterModel } from "../../../models/auth";
import { NavigateFunction } from "react-router";
import { getUserInfo } from "../../../services/user";
import { register, signIn, signOut } from "../../../services/auth";
import { setInitialized } from "../app";

const slice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setUser: (state: UserStore, { payload }: PayloadAction<UserModel>) => {
          state.id = payload.id;
          state.firstName = payload.firstName;
          state.lastName = payload.lastName;
          state.email = payload.email;
          state.isAuthenticated = payload.isAuthenticated;
        },
        setAuthenticated: (state: UserStore, { payload }: PayloadAction<boolean>) => {
          state.isAuthenticated = payload;
        },
        resetUser: (state: UserStore) => {
          state.id = initialState.id;
          state.firstName = initialState.firstName;
          state.lastName = initialState.lastName;
          state.email = initialState.email;
          state.isAuthenticated = initialState.isAuthenticated;
        }
    }
});

export const { setUser, setAuthenticated, resetUser } = slice.actions;
export default slice;

export const init =
  (navigate: NavigateFunction): AsyncAppThunk =>
  async (dispatch, store) => {
    try {
      const userInfo = await getUserInfo();

      await dispatch(setUser({ ...userInfo.data, isAuthenticated: true }));
      dispatch(setInitialized(true));

      navigate('/dashboard');
    }
    catch {
      await dispatch(setInitialized(true));
    }
  };

export const authenticateUser =
  (model: LoginModel, navigate: NavigateFunction): AsyncAppThunk =>
  async (dispatch, store) => {
    const response = await signIn(model);

    if (response.status != 200) {
        // TODO: Add sign in failed validation errors
    }

    const userInfo = await getUserInfo();

    await dispatch(setUser({ ...userInfo.data, isAuthenticated: true }));
    await dispatch(setInitialized(true));

    navigate('/dashboard');
  };

export const registerUser =
  (model: RegisterModel, navigate: NavigateFunction): AsyncAppThunk =>
  async (dispatch, store) => {
    const response = await register(model);

    if (response.status != 200) {
        // TODO: Add sign in failed validation errors
    }

    const userInfo = await getUserInfo();

    await dispatch(setUser({ ...userInfo.data, isAuthenticated: true }));
    await dispatch(setInitialized(true));

    navigate('/dashboard');
  };

export const signOutUser =
  (): AsyncAppThunk =>
  async (dispatch, store) => {
    const response = await signOut();

    if (response.status == 200) {
      dispatch(resetUser());
    }
  };