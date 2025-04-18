export interface AuthFormProps {
  pageName: string;
  email: string;
  password: string;
  setEmail: (email: string) => void;
  setPassword: (password: string) => void;
  onSubmit: () => void;
}
