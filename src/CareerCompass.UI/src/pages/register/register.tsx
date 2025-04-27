import { connect } from "react-redux";
import { AppDispatch } from "../../store/app-dispatch";
import ApplicationState from "../../store/application-state";
import { authenticateUser, registerUser } from "../../store/slices/user";
import { useState } from "react";
import { NavigateFunction, useNavigate } from "react-router";
import { LoginModel, RegisterModel } from "../../models/auth";
import { Header } from "../../components/header";
import AuthForm from "../../components/authForm";
import { RegisterProps } from "./register.props";

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const passwordRegex = /^(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$/;

const Register = (props: RegisterProps) => {
  const navigate = useNavigate();

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [validationErrors, setValidationErrors] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
  });

  const onSubmit = () => {
    let errors = { firstName: "", lastName: "", email: "", password: "" }; 
    let isValid = true;

    if  (!firstName) {
      errors.firstName = "First name is required.";
      isValid = false;
    }
    if  (!lastName) {
      errors.lastName = "Last name is required.";
      isValid = false;
    }
    if (!email) {   
      errors.email = "Email is required.";
      isValid = false;
    } 
    else if (!emailRegex.test(email)) {
      errors.email = "A valid email address is required.";
      isValid = false;
    }
    if (!password) {  
      errors.password = "Password is required.";
      isValid = false;
    }
    else if (!passwordRegex.test(password)) { 
      errors.password = "A valid strong password is required.";
      isValid = false;
    }

    setValidationErrors(errors);

    if(isValid) {
      setValidationErrors({ firstName: "", lastName: "", email: "", password: "" });
      props.registerUser({ firstName, lastName, email, password }, navigate);
    }
  };

  return (
    <div>
      <div className="w-full bg-linear-127 from-[#00A7B3] to-[#002847] relative">
        <Header pageName="register" />

        <div className="h-[960px] object-cover">
          <img src="/src/assets/humanFace.png" />
        </div>
        <div className="absolute top-1/2 left-3/4 -translate-x-1/2 -translate-y-1/2 z-10">
          <AuthForm
            pageName="register"
            firstName={firstName}
            lastName={lastName}
            email={email}
            password={password}
            setFirstName={setFirstName}
            setLastName={setLastName}
            setEmail={setEmail}
            setPassword={setPassword}
            onSubmit={onSubmit}
          />
          <div>
            {validationErrors.firstName && (
              <div className="text-red-500">{validationErrors.firstName}</div>
            )}
          </div>
          <div>
            {validationErrors.lastName && (
              <div className="text-red-500">{validationErrors.lastName}</div>
            )}  
            </div>
          <div>
            {validationErrors.email && (
              <div className="text-red-500">{validationErrors.email}</div>
            )} 
          </div>
          <div>
            {validationErrors.password && (
              <div className="text-red-500">{validationErrors.password}</div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

const mapStateToProps = (state: ApplicationState) => ({
  user: state.user,
});

const mapDispatchToProps = (dispatch: AppDispatch) => ({
  registerUser: (model: RegisterModel, navigate: NavigateFunction) =>
    dispatch(registerUser(model, navigate)),
});

export default connect(mapStateToProps, mapDispatchToProps)(Register);
