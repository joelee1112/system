import Vue from 'vue'
export const users = Vue.resource('./api/users{/id}', {}, {
    roles: {
        method: 'get',
        url: './api/users/roles{/id}'
    },
    groups: {
        method: 'get',
        url: './api/users/groups{/id}'
    }
});
export const roles = Vue.resource('./api/roles{/id}', {}, {
    rename: {
        method: 'put',
        url: './api/roles/rename{/id}'
    },
    move: {
        method: 'put',
        url: './api/roles/move'
    },
    functions: {
        method: 'get',
        url: './api/roles/functions{/id}'
    },
    updateFunctions: {
        method: 'put',
        url: './api/roles/functions{/id}'
    },

});

export const groups = Vue.resource('./api/groups{/id}', {}, {
    rename: {
        method: 'put',
        url: './api/groups/rename{/id}'
    },
    move: {
        method: 'put',
        url: './api/groups/move'
    },
    functions: {
        method: 'get',
        url: './api/groups/functions'
    },
});
export const forms = Vue.resource('./api/forms{/id}');
export const layouts = Vue.resource('./api/layouts{/id}');
export const functions = Vue.resource('./api/functions{/type}{/id}', {}, {
    rename: {
        method: 'put',
        url: './api/functions{/type}/rename{/id}'
    },
    move: {
        method: 'put',
        url: './api/functions{/type}/move{/id}'
    },
    copy: {
        method: 'post',
        url: './api/functions{/type}/copy{/id}'
    }
});
export const authentication = Vue.resource('./api/authentication', {}, {
    signIn: {
        method: 'post',
        url: './api/authentication/sign-in'
    },
    signOut: {
        method: 'post',
        url: './api/authentication/sign-out'
    },
    facebook: {
        method: 'get',
        url: './api/authentication/signIn/facebook/{accessToken}'
    },
    refresh: {
        method: 'get',
        url: './api/authentication/refresh'
    },
    switch: {
        method: 'get',
        url: './api/authentication/switch/{id}'
    },
    forgetPassword: {
        method: 'post',
        url: './api/authentication/forgetPassword/{id}'
    }
});
export const my = Vue.resource('./api/my', {}, {
    info: {
        method: 'get',
        url: './api/my/info'
    },
    functions: {
        method: 'get',
        url: './api/my/functions'
    },
    system: {
        method: 'get',
        url: './api/my/system'
    }
});
export const contents = Vue.resource('./api/contents{/id}', {}, {
    rename: {
        method: 'put',
        url: './api/contents/rename{/id}'
    },
    move: {
        method: 'put',
        url: './api/contents/move'
    },
    copy: {
        method: 'post',
        url: './api/contents/copy'
    }
});
export const picklists = Vue.resource('./api/picklists{/id}', {}, {
    rename: {
        method: 'put',
        url: './api/picklists/rename{/id}'
    },
    move: {
        method: 'put',
        url: './api/picklists/move'
    },
    copy: {
        method: 'post',
        url: './api/picklists/copy'
    }
});
export const system = Vue.resource('./api/system{/id}');
export const password = Vue.resource('./api/password', {}, {
    update: {
        method: 'put',
        url: './api/password'
    }
});