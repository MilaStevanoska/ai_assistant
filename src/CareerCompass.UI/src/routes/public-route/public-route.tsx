import { useEffect } from 'react';
import { connect } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';
import { PublicRouteProps } from './public-route.props';
import ApplicationState from '../../store/application-state';
import { UserModel } from '../../models/user';

const PublicRoute = (props: PublicRouteProps) => {
  const location = useLocation();
  const navigate = useNavigate();

  useEffect(() => {
    if (!props.isAppInitialized || !props.user.isAuthenticated) {
        return;
    }

    if (location.pathname === '/login' || location.pathname === '/register') {
        navigate('/dashboard');
    }
  }, [props.user, location]);

  if (!props.isAppInitialized) {
    return null;
  }

  if (props.user.isAuthenticated && (location.pathname === '/login' || location.pathname === '/register')) {
    return null;
  }

  return <>{props.children}</>;
};

const mapStateToProps = (state: ApplicationState) => {
    const { user, app } = state;
    
    return {
        user: user as UserModel,
        isAppInitialized: app.isInitialized
    }
};

export default connect(mapStateToProps, null)(PublicRoute);
