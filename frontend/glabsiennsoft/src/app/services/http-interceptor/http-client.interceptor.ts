import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../../environments/environment';

@Injectable()
export class CustomInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      var request = new HttpRequest(req.method as 'DELETE' | 'GET' | 'HEAD' | 'JSONP' | 'OPTIONS', `${environment.uri}/${req.url}`)
      return next.handle(request);
  }
}