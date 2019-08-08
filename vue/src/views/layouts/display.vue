<template>
<div>
    <div>
        <textarea v-model="inputhtml" />
        <button @click="save">修改</button>
    </div>
    <div id="display_content">
        <div v-html="displayhtml">
        </div>
    </div>
</div>
</template>

<script>
import { rowtype } from "@/views/layouts/enum";

export default {
  name: "Display",
  data: function() {
      return {
          inputhtml: [],
          displayhtml: 'true',
          layout: [{"childs":[{"childs":[{"childs":[],"type":"row"},{"childs":[],"type":"row"},{"childs":[],"type":"row"},{"childs":[],"type":"editor","value":"789999999"},{"childs":[],"type":"vue"}],"type":"column","width":100,"widthfix":false}],"type":"row"},{"childs":[{"childs":[],"type":"column","width":50,"widthfix":false},{"childs":[],"type":"column","width":50,"widthfix":false}],"type":"row"},{"childs":[{"childs":[],"type":"column","width":100,"widthfix":false}],"type":"row"}]
      }
  },
  methods: {
    save() {
        this.layout = JSON.parse(this.inputhtml);
        let output = '';    
        for (var i = 0; i < this.layout.length; i++) {
            output += this.gettag(this.layout[i], this.getchild(this.layout[i].childs));
        }
        this.displayhtml = output;
    },
    getchild(items) {
        let output = '';
        for (var i = 0; i < items.length; i++) {
            output += this.gettag(items[i], this.getchild(items[i].childs));
        }
        return output;
    },
    gettag(self, content) {
        content = self.type == rowtype.editor ? self.value : content;
        let width = self.type == rowtype.column ? this.getwidth(self.width) : '';
        return '<div ' + this.getattr('class', self.type) + ' ' + width +'>' + content + '</div>';
    },
    getattr(key, value) {
        return key + '=' + '\'' + value + '\'';
    },
    getwidth(width) {
        return this.getattr('style','width:' + width + '%');
    }
  }
}
</script>

<style lang="scss">
    .column {
    float: left;
    }
    .editor {
        text-align: left;
    }
</style>
