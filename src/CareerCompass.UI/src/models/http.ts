import type { CancelToken } from 'axios';

export interface PageResult<T> {
  items: T[];
}

export interface DataServiceResponse<T = any> {
  data: T;
  status: number;
  statusText: string;
  headers: any;
  config: DataServiceRequestConfig;
  request?: any;
}

export interface DataServiceError<T> extends Error {
  code?: string;
  response?: DataServiceResponse<T>;
  isError: boolean;
}

export interface DataServiceRequestConfig {
  url?: string;
  baseURL?: string;
  headers?: any;
  params?: any;
  data?: any;
  timeout?: number;
  timeoutErrorMessage?: string;
  withCredentials?: boolean;
  onUploadProgress?: (progressEvent: any) => void;
  onDownloadProgress?: (progressEvent: any) => void;
  maxContentLength?: number;
  cancelToken?: CancelToken;
}
