import axios, { AxiosInstance, AxiosError } from "axios";
import { DataServiceError, DataServiceRequestConfig, DataServiceResponse } from "../../models/http";

export interface HttpServiceConfig<T> {
  baseUrl: string;
  headers?: { [key: string]: string };
  withCredentials?: boolean;
  onError?: (error: DataServiceError<T>) => Promise<DataServiceError<T>>;
}
  
export default class HttpService {
  private readonly service: AxiosInstance;
  private onError?: (error: DataServiceError<unknown>) => Promise<DataServiceError<unknown>>;
  
  constructor(config?: HttpServiceConfig<any>) {
    if (config) {
        this.service = axios.create({
          baseURL: config.baseUrl,
          headers: config.headers || {},
          withCredentials: config.withCredentials
        });
  
        this.onError = config.onError;
  
        this.service.interceptors.response.use(
          (response) => {
            return Promise.resolve(response);
          },
          (error) => {
            if (this.onError) {
              return this.onError(mapAxiosErrorToDataServiceError(error));
            }
  
            return Promise.reject(error);
          }
        );
    } else {
      this.service = axios;
    }
  }
  
  public setHeaderValue = (name: string, value: string) => (this.service.defaults.headers[name] = value);
  
  public setBaseUrl = (baseURL: string) => (this.service.defaults.baseURL = baseURL);
  
  public setErrorHandler = (onError: (error: DataServiceError<unknown>) => Promise<DataServiceError<unknown>>) => {
    this.onError = onError;
  };
  
  public get = <T>(url: string, config?: DataServiceRequestConfig): Promise<DataServiceResponse<T>> =>
    this.service.get<T>(url, config);
  
  public post = <TModel, TResponse = TModel>(
      url: string,
      model?: TModel,
      config?: DataServiceRequestConfig
    ): Promise<DataServiceResponse<TResponse>> => this.service.post<TResponse>(url, model, config);
}

export const mapAxiosErrorToDataServiceError = <T>(error: AxiosError<T>): DataServiceError<T> => {
  return {
    ...error,
    isError: error.isAxiosError
  };
};