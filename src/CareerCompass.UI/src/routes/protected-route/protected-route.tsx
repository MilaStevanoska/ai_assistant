import { useEffect } from 'react';
import { connect } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';
import { ProtectedRouteProps } from './protected-route.props';
import ApplicationState from '../../store/application-state';
import { UserModel } from '../../models/user';

const ProtectedRoute = (props: ProtectedRouteProps) => {
  const location = useLocation();
  const navigate = useNavigate();
  const { user, allowedPaths, children } = props;

  useEffect(() => {
    if (!props.isAppInitialized) {
      return;
    }

    const isProtected = !allowedPaths.some((path) =>
      location.pathname.startsWith(path)
    );

    if (isProtected && !user.isAuthenticated) {
      navigate('/login');
    }
  }, [location, user.isAuthenticated, allowedPaths]);

  if (!props.isAppInitialized) {
    return null;
  }

  const isProtected = !allowedPaths.some((path) =>
    location.pathname.startsWith(path)
  );

  if (isProtected && !user.isAuthenticated) {
    return null;
  }

  return <>{children}</>;
};

const mapStateToProps = (state: ApplicationState) => {
    const { user, app } = state;
    
    return {
        user: user as UserModel,
        isAppInitialized: app.isInitialized,
        allowedPaths: ['/login', '/register']
    }
};

export default connect(mapStateToProps, null)(ProtectedRoute);
