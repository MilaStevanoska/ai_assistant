import type { Action } from '@reduxjs/toolkit';
import type { ThunkAction } from 'redux-thunk';
import ApplicationState from './application-state';

type Thunk<TStore> = ThunkAction<void, TStore, null, Action<string>>;
type AsyncThunk<TStore, TReturnType = void> = ThunkAction<Promise<TReturnType>, TStore, null, Action<string>>;

export type AppThunk = Thunk<ApplicationState>;
export type AsyncAppThunk<T = void> = AsyncThunk<ApplicationState, T>;