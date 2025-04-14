import { DataServiceResponse, DataServiceError } from "../../models/http";
import HttpService from "./httpService";

const defaultConfiguration = {
  withCredentials: true,
  onSuccess: (response: DataServiceResponse<any>) => Promise.resolve(response),
  onError: <T>(error: DataServiceError<T>) => {
    const expectedError = error.response && error.response.status >= 400 && error.response.status <= 500;

    if (expectedError && error.response && (error.response as any).data.dictionary) {
        const errors = (error.response as any).data.dictionary;
  
        Object.keys(errors).forEach((x) => {
          let message = `${x}: ${errors[x]}`;
          console.error(message);
        });
    } else {
        console.error("An unexpected error occurred");
    }
  
    return Promise.reject(error);
  }
};

export const authHttpService = new HttpService({ baseUrl: 'https://localhost:7172/api/v1/auth', ...defaultConfiguration });
export const userHttpService = new HttpService({ baseUrl: 'https://localhost:7172/api/v1/user', ...defaultConfiguration });