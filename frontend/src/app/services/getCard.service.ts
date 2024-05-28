import { Injectable, InjectionToken, Provider, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { PostService } from './post.service';
import { Post } from '../interfaces/interface';

export const FLAT_TOKEN = new InjectionToken<Observable<Post>>('Текущая квартира');

export const FLAT_PROVIDER: Provider = {
    provide: FLAT_TOKEN,
    useFactory: () => {
        const route = inject(ActivatedRoute);
        const service = inject(PostService);

        return route.params.pipe(
            switchMap(params => {
                const id = params["id"];

                return service.getPostByID(id);
            }),
        );
    }
}
