import type { Action } from 'redux';
import type { ThunkDispatch } from 'redux-thunk';
import type ApplicationState from './application-state';

export type AppDispatch = ThunkDispatch<ApplicationState, null, Action<string>>;