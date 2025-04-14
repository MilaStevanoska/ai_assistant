import slice from './store';

export * from './store';

export type { ApplicationStore } from './state';
export const ApplicationReducer = slice.reducer;