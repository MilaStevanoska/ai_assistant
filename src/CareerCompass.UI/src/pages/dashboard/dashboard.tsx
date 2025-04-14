import { connect } from "react-redux";
import { AppDispatch } from "../../store/app-dispatch";
import ApplicationState from "../../store/application-state";
import { signOutUser } from "../../store/slices/user";
import { DashboardProps } from "./dashboard.props";

const Dashboard = (props: DashboardProps) => {
    return (
        <div>
            Email is {props.user.email} <br/>
            <button onClick={() => props.signOut()}>Sign out</button>
        </div>
    );
}

const mapStateToProps = (state: ApplicationState) => ({
  user: state.user
});

const mapDispatchToProps = (dispatch: AppDispatch) => ({
  signOut: () => dispatch(signOutUser())
})

export default connect(mapStateToProps, mapDispatchToProps)(Dashboard);