import { useNavigate } from "react-router";
import { AuthFormProps } from "./authForm.props";

  const AuthForm = ({
    pageName,
    email,
    password,
    setEmail,
    setPassword,
    onSubmit,
  }: AuthFormProps) => {

    const navigate = useNavigate();

  const goToRegister = () => {
    navigate("/register");
  };

  return (
    <div className="w-full pt-4 pb-11 px-11 text-white bg-white/32 rounded-3xl">
      <div className="inter-bold text-center text-[40px]">logo</div>
      {pageName == "login" ? (
        <div className="flex flex-col">
          <div className="inter-bold text-3xl pt-7">Login</div>
          <label className="inter-regular pb-2 pt-7">Email</label>
          <input
            type="text"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="email@gmail.com"
            className="inter-regular w-[375px] p-2 px-5 bg-white text-[#A2A2A2] rounded-xl"
          />
          <label className="inter-regular pb-2 pt-7">Password</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="password"
            className="inter-regular p-2 px-5 bg-white text-[#A2A2A2] rounded-xl"
          />
          <button className="inter-regular py-2  text-left">
            Forgot your password?
          </button>
          <button
            onClick={onSubmit}
            className="bg-[#003F6F] inter-bold text-xl p-3 rounded-xl mt-7"
          >
            Sign in
          </button>
          <div className="inter-regular pt-7 text-left">
            Don't have an account yet?{" "}
            <button
              onClick={goToRegister}
              className="pl-3 inter-bold underline"
            >
              Register
            </button>
          </div>
        </div>
      ) : (
        <div className="flex flex-col">
          <div className="inter-bold text-3xl pt-7">Register</div>
          <label className="inter-regular pb-2 pt-7">Name</label>
          <input
            type="text"
            placeholder="Your name"
            className="inter-regular w-[375px] p-2 px-5 bg-white text-[#A2A2A2] rounded-xl"
          />
          <label className="inter-regular pb-2 pt-7">Surname</label>
          <input
            type="text"
            placeholder="Your surname"
            className="inter-regular w-[375px] p-2 px-5 bg-white text-[#A2A2A2] rounded-xl"
          />
          <label className="inter-regular pb-2 pt-7">Email</label>
          <input
            type="text"
            placeholder="email@gmail.com"
            className="inter-regular w-[375px] p-2 px-5 bg-white text-[#A2A2A2] rounded-xl"
          />
          <label className="inter-regular pb-2 pt-7">Password</label>
          <input
            type="text"
            placeholder="password"
            className="inter-regular w-[375px] p-2 px-5 bg-white text-[#A2A2A2] rounded-xl"
          />
          <button className="bg-[#003F6F] inter-bold text-xl p-3 rounded-xl mt-7">
            Sign up
          </button>
          <div className="inter-regular pt-7 text-left">
            Already have an account?{" "}
            <button className="pl-3 inter-bold underline">Login</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default AuthForm;
