import { connect } from 'react-redux';
import ApplicationState from './store/application-state'
import { init, setAuthenticated, UserStore } from './store/slices/user';
import './App.scss'
import { NavigateFunction, Route, Routes, useNavigate } from 'react-router';
import ProtectedRoute from './routes/protected-route/protected-route';
import PublicRoute from './routes/public-route/public-route';
import { AppDispatch } from './store/app-dispatch';
import Dashboard from './pages/dashboard/dashboard';
import Login from './pages/login/login';
import { useEffect } from 'react';

interface AppProps {
  init: (navigate: NavigateFunction) => void;
}

const App = (props: AppProps) => {
  const navigate = useNavigate();

  useEffect(() => {
    props.init(navigate);
  }, []);

  return (
    <>
      <Routes>
        <Route path='/' element={
          <ProtectedRoute>sasa</ProtectedRoute>
        }/>
        <Route path='/login' element={
          <PublicRoute>
            <Login />
          </PublicRoute>
        }/>
        <Route path='/dashboard' element={
          <ProtectedRoute>
            <Dashboard />
          </ProtectedRoute>
        } />
      </Routes>
    </>
  )
}

const mapStateToProps = (state: ApplicationState) => ({
  user: state.user
});

const mapDispatchToProps = (dispatch: AppDispatch) => ({
  init: (navigate: NavigateFunction) => dispatch(init(navigate))
})

export default connect(mapStateToProps, mapDispatchToProps)(App);
