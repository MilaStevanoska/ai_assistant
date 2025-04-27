import slice from './store';

export * from './store';

export type { MasterDataStore } from './state';
export const MasterDataReducer = slice.reducer;