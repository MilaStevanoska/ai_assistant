import slice from './store';

export * from './store';

export type { UserStore } from './state';
export const UserReducer = slice.reducer;