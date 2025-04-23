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
      <div className="w-full bg-linear-127 from-[#00A7B3] to-[#002847] relative">
        <Header pageName="login" />

        <div className="h-[960px] object-cover">
          <img src="/src/assets/humanFace.png" />
        </div>
        <div className="absolute top-1/2 left-3/4 -translate-x-1/2 -translate-y-1/2 z-10">
          <AuthForm
            pageName="login"
            email={email}
            password={password}
            setEmail={setEmail}
            setPassword={setPassword}
            onSubmit={onSubmit}
          />
        </div>
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
