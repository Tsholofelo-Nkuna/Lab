export class ResponseDto<TData>{
  data?: TData;
  message= "";
  errors : string[] = []
}
