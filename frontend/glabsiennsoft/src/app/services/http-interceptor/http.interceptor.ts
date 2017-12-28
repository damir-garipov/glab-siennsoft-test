import { Injectable } from "@angular/core";
import { ConnectionBackend, RequestOptions, RequestOptionsArgs, Response, Http, Headers } from "@angular/http";
import { Observable } from "rxjs/Rx";
import { environment } from '../../../environments/environment';

@Injectable()
export class InterceptedHttp extends Http {
    constructor(backend: ConnectionBackend, defaultOptions: RequestOptions) {
        super(backend, defaultOptions);
        this.baseUrl = environment.uri;
    }

    baseUrl:string = "";

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        console.log(`GET request Base url is: ${this.baseUrl}`);
        return super.get(this.baseUrl + url, this.getRequestOptionArgs(options));
    }

    post(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        return super.post(this.baseUrl + url, body, this.getRequestOptionArgs(options));
    }

    put(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        return super.put(this.baseUrl + url, body, this.getRequestOptionArgs(options));
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return super.delete(this.baseUrl + url, this.getRequestOptionArgs(options));
    }

    private getRequestOptionArgs(options?: RequestOptionsArgs): RequestOptionsArgs {
        if (options == null) {
            options = new RequestOptions();
        }
        if (options.headers == null) {
            options.headers = new Headers();
        }

        options.headers.append("Accept", "application/json");
        options.headers.append('Content-Type', 'application/json');
        options.headers.append('X-Requested-With', 'XMLHttpRequest');

        return options;
    }
}