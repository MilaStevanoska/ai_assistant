import { createRoot } from 'react-dom/client';
import './index.css';
import App from './App.tsx';
import configureProjectStore from './store/configure-store.ts';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router';

const initApp = () => {
  const store = configureProjectStore();

  const render = (Component: any) => {
    createRoot(document.getElementById('root')!)
      .render(
        <Provider store={store}>
          <BrowserRouter>
              <Component />
          </BrowserRouter>
        </Provider>
      );
  };

  render(App);
}

initApp();