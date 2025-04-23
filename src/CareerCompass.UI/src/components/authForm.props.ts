export interface AuthFormProps {
  pageName: string;
  email: string;
  password: string;
  firstName?: string;
  lastName?: string;
  setEmail: (email: string) => void;
  setPassword: (password: string) => void;
  setFirstName?: (firstName: string) => void;  
  setLastName?: (lastName: string) => void;
  onSubmit: () => void;
}
