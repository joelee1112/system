import { action } from "@/views/layouts/enum";
export var mixin = {
    created() {
        var layouts;
      },
    computed: {
        nextshow() {
          return this.sort != (this.count - 1);
        },
        prevshow() {
          return this.sort != 0;
        }
      },
    methods: {
        menushow: function(event) {
            $(event.target).find('.menu').show();
        },
        menuhide: function(event) {
            $(event.target).find('.menu').hide();
        },
        swap: function(a, i, j) {
            a = a.slice();
            [a[i], a[j]] = [a[j], a[i]];
            return a;
        },
        prev: function() {
            this.ReturnValue(action.moveprev);
        },
        next: function() {
            this.ReturnValue(action.movenext);
        },
        remove: function() {
            this.ReturnValue(action.remove);
        }
    }
  }