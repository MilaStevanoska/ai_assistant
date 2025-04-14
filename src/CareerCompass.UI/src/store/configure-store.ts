import { combineReducers, Reducer } from 'redux';
import { configureStore } from '@reduxjs/toolkit';
import { createLogger } from 'redux-logger';

import { reducers } from './root-reducer';
import { createReduxHistoryContext, RouterState } from 'redux-first-history';
import { createBrowserHistory } from 'history';

export function configureProjectStore() {
  const { createReduxHistory, routerMiddleware, routerReducer } = createReduxHistoryContext({ history: createBrowserHistory() });
  let middleware = [routerMiddleware];
  
  if (process.env.NODE_ENV !== 'production') {
    middleware.push(createLogger());
  }

  const store = configureStore({
    reducer: getRootReducer(routerReducer),
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(middleware)
  });

  return store;
}

function getRootReducer(routerReducer: Reducer<RouterState>) {
  return combineReducers({
    ...reducers,
    router: routerReducer
  });
}

export default configureProjectStore;