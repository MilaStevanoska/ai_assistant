import { connect } from "react-redux";
import { AppDispatch } from "../../store/app-dispatch";
import ApplicationState from "../../store/application-state";
import { authenticateUser } from "../../store/slices/user";
import { useState } from "react";
import { NavigateFunction, useNavigate } from "react-router";
import { LoginModel } from "../../models/auth";

const Register = () => {
    const navigate = useNavigate();

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');



    return (
        <div>
            Register
            <div>
                Email Address <br/>
                <input type="text" value={email} onChange={(e) => setEmail(e.target.value)} />
            </div>
            <div>
                Password <br/>
                <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
            </div>
        </div>
    );
}

const mapStateToProps = (state: ApplicationState) => ({
  user: state.user
});

const mapDispatchToProps = (dispatch: AppDispatch) => ({
  authenticateUser: (model: LoginModel, navigate: NavigateFunction) => dispatch(authenticateUser(model, navigate))
})

export default connect(mapStateToProps, mapDispatchToProps)(Register);