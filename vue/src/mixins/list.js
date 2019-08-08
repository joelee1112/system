export default {
  data() {
    return {
      rows: []
    };
  },
  mounted() {
    this.load().then(this.init);
  },
  methods: {
    init() {
      this.table = $(".table").dataTable({
        aoColumns: [...new Array($('table th').length - 1), {
          bSortable: false
        }]
      });
    },
    load() {
      return new Promise(resolve => {
        this.resource.get().then(a => {
          this.rows = a.body;
          resolve();
        });
      })
    },
    remove(id, i) {
      if (!confirm("確定要刪除嗎？")) return;
      this.resource.delete({
        id: id
      }).then(a => {
        this.rows.splice(i, 1);
        this.table.fnDeleteRow(i);
      });
    }
  }
}
