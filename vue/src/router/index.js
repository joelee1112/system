import Vue from 'vue'
import Router from 'vue-router'
import identity from './identity'

Vue.use(Router)

let pages = {
    "/users": () =>
        import ("views/users"),
    "/users/create": () =>
        import ("views/users/create"),
    "/users/edit/:id": () =>
        import ("views/users/edit"),
    "/roles": () =>
        import ("views/roles"),
    "/groups": () =>
        import ("views/groups"),
    "/forms": () =>
        import ("views/forms"),
    "/forms/create": () =>
        import ("views/forms/create"),
    "/forms/edit/:id": () =>
        import ("views/forms/edit"),
    "/functions": () =>
        import ("views/functions"),
    "/layouts": () =>
        import ("views/layouts"),
    "/layouts/create": () =>
        import ("views/layouts/create"),
    "/layouts/edit/:id": () =>
        import ("views/layouts/edit"),
    "/contents": () =>
        import ("views/contents"),
    "/picklists": () =>
        import ("views/picklists"),
    "/password": () =>
        import ("views/password"),
};

let routes = [{
    path: "",
    component: () =>
        import ("views/shared/layout"),
    children: [{
            name: "/",
            path: "/",
            component: () =>
                import ("views/home")
        },
        ...Object.keys(pages).map(b => {
            return {
                name: b,
                path: b,
                component: pages[b]
            };
        })
    ]
}];

export default new Router({
    routes: [{
        path: '/login',
        component: () =>
            import ('views/login'),
        meta: {
            allowAnonymous: true
        }
    }, {
        path: '/forgetPassword',
        component: () =>
            import ('views/ForgetPassword'),
        meta: {
            allowAnonymous: true
        }
    }, ...routes, {
        path: "",
        component: () =>
            import ("views/shared/layout"),
        children: [{
            name: '404',
            path: "*",
            component: () =>
                import ("views/404")
        }]
    }]
})

identity.authorize();