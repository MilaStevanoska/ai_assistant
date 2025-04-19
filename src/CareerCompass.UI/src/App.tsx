import { connect } from "react-redux";
import ApplicationState from "./store/application-state";
import { init, setAuthenticated, UserStore } from "./store/slices/user";
import "./App.css";
import { NavigateFunction, Route, Routes, useNavigate } from "react-router";
import ProtectedRoute from "./routes/protected-route/protected-route";
import PublicRoute from "./routes/public-route/public-route";
import { AppDispatch } from "./store/app-dispatch";
import Dashboard from "./pages/dashboard/dashboard";
import Login from "./pages/login/login";
import { useEffect } from "react";
import Welcome from "./pages/welcome/welcome";
import Register from "./pages/register/register";

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
        <Route
          path="/"
          element={
            <PublicRoute>
              <Welcome />
            </PublicRoute>
          }
        />
        <Route
          path="/login"
          element={
            <PublicRoute>
              <Login />
            </PublicRoute>
          }
        />
        <Route
          path="/register"
          element={
            <PublicRoute>
              <Register />
            </PublicRoute>
          }
        />
        <Route
          path="/dashboard"
          element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          }
        />
      </Routes>
    </>
  );
};

const mapStateToProps = (state: ApplicationState) => ({
  user: state.user,
});

const mapDispatchToProps = (dispatch: AppDispatch) => ({
  init: (navigate: NavigateFunction) => dispatch(init(navigate)),
});

export default connect(mapStateToProps, mapDispatchToProps)(App);
