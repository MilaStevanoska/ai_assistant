import { useNavigate } from "react-router";

export const Header = ({ pageName }: { pageName: string }) => {
    const navigate = useNavigate();

    const goToLogin = () =>{
        navigate("/login");
    }
    const goToRegister = () =>{
        navigate("/register")
    }

    return (
        <div className="w-full flex justify-between inria-sans-bold text-white px-11 pt-7 pb-4 border-b border-white">
        <div className="text-3xl">CareerCompassAI</div>
        {pageName == "welcome" ? (
          <div>
            <button onClick={goToRegister} className="px-7 py-2 text-xl bg-[#0071C7] rounded-3xl">
              Sign up
            </button>
            <button onClick={goToLogin}  className="ml-4 px-7 py-2 text-xl bg-[#B1B1B1] rounded-3xl">
              Sign in
            </button>
          </div>
        ) : pageName == "login" ? (
          <div className="inria-sans-regular text-md">
            <button className="px-7 py-2 underline">Sign In </button>
            <button onClick={goToRegister} className="ml-4 px-5 py-1  bg-[#D9D9D9] text-black rounded-3xl">
              Register
            </button>
          </div>
        ) : (
          <div className="inria-sans-regular text-md">
            <button className="px-7 py-2 underline">Sign Up</button>
            <button onClick={goToLogin} className="ml-4 px-5 py-1  bg-[#D9D9D9] text-black rounded-3xl">
              Login
            </button>
          </div>
        )}
      </div>
    );
  };
  