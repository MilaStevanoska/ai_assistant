import { connect } from "react-redux";
import { AppDispatch } from "../../store/app-dispatch";
import ApplicationState from "../../store/application-state";
import { authenticateUser } from "../../store/slices/user";
import { LoginProps } from "./login.props";
import { useState } from "react";
import { NavigateFunction, useNavigate } from "react-router";
import { LoginModel } from "../../models/auth";
import { Header } from "../../components/header";
import AuthForm from "../../components/authForm";

const Login = (props: LoginProps) => {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const onSubmit = () => {
    // TODO: Add validation
    props.authenticateUser({ email, password }, navigate);
  };

  return (
    <div>
      This is the login page
      <div>
        Email Address <br />
        <input
          type="text"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <div>
        Password <br />
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>
      <button onClick={onSubmit}>Sign In</button>
    </div>
  );
};

const mapStateToProps = (state: ApplicationState) => ({
  user: state.user,
});

const mapDispatchToProps = (dispatch: AppDispatch) => ({
  authenticateUser: (model: LoginModel, navigate: NavigateFunction) =>
    dispatch(authenticateUser(model, navigate)),
});

export default connect(mapStateToProps, mapDispatchToProps)(Login);
