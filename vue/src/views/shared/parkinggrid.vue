<template>
  <div>
    <table id="jqGrid"></table>
    <div id="jqGridPager"></div>
  </div>
</template>

<script>
import { parking, options } from "@/resource";
import popup from "shared/popup";

export default {
  props: ["pkcarpark"],
  components: {
    popup
  },
  data() {
    return {
      pk: this.pkcarpark,
      optionval: {
        baseAuthority: "",
        operator: "",
        baseCarParkType: "",
        baseCity: "",
        baseOperationType: "",
        baseParkingGuideType: "",
        baseSupervisionType: "",
        baseParkingType: "",
        baseParkingSiteType: "",
        baseTowns: ""
      }
    };
  },
  mounted() {
    let loading = $(".loading");
    loading.show();
    let p1 = this.loadMain();
    let p2 = this.loadOption();
    Promise.all([p1, p2]).then(values => {
      this.init();
      loading.hide();
    });
  },
  watch: {
    pk(v) {
      this.$emit("update:pkcarpark", v);
    }
  },
  methods: {
    getoptionval(obj, type) {
      for (const [key, value] of Object.entries(obj)) {
        if (key != undefined || value != undefined) {
          this.optionval[type] += key + ":" + value + ";";
        }
      }
    },
    loadMain() {
      return new Promise(resolve => {
        parking.get().then(a => {
          this.parkingdata = a.body;
          resolve();
        });
      });
    },
    loadOption() {
      return new Promise(resolve => {
        Promise.all([
          options.getBaseAuthority(),
          options.getOperator(),
          options.getBaseCarParkType(),
          options.getBaseCity(),
          options.getBaseOperationType(),
          options.getBaseParkingGuideType(),
          options.getBaseSupervisionType(),
          options.getBaseParkingType(),
          options.getBaseParkingSiteType(),
          options.getBaseTowns()
        ]).then(r => {
          r.forEach((a, i) => {
            this.getoptionval(a.body, Object.keys(this.optionval)[i]);
          });
          resolve();
        });
      });
    },
    reload() {
      let p1 = this.loadMain();
      let p2 = this.loadOption();
      Promise.all([p1, p2]).then(values => {
        $("#jqGrid").jqGrid("clearGridData");
        $("#jqGrid")
          .jqGrid("setGridParam", { data: this.parkingdata })
          .trigger("reloadGrid");
        $(".loading").hide();
      });
    },

    init() {
      let vm = this;
      $("#jqGrid").jqGrid({
        datatype: "local",
        data: vm.parkingdata,
        colModel: [
          {
            name: "pkOffStreetCarPark",
            index: "pkOffStreetCarPark",
            hidden: true,
            editable: false,
            key: true,
            editrules: { edithidden: true },
            hidedlg: true
          },
          {
            label: "地區既用中之停車場代碼",
            name: "carParkId",
            editable: true,
            autosize: true
          },
          {
            label: "業管機關",
            name: "fkBaseAuthority",
            index: "fkBaseAuthority",
            autosize: true,
            editable: true,
            edipkype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseAuthority
            }
          },
          {
            label: "營運業者",
            name: "fkOperator",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.operator
            },

            editable: true,
            autosize: true
          },
          {
            label: "停車場類型",
            name: "fkBaseCarParkType",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseCarParkType
            },

            editable: true,
            autosize: true
          },
          {
            label: "所在城市",
            name: "fkBaseCity",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseCity
            },

            editable: true,
            autosize: true
          },
          {
            label: "營運種類",
            name: "fkBaseOperationType",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseOperationType
            },
            editable: true,
            autosize: true
          },
          {
            label: "停車導引類型",
            name: "fkBaseParkingGuideType",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseParkingGuideType
            },
            autosize: true,
            editable: true
          },
          {
            label: "監視系統類型",
            name: "fkBaseSupervisionType",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseSupervisionType
            },
            editable: true,
            autosize: true
          },
          {
            label: "所在行政區(鄉鎮區)",
            name: "fkBaseTown",
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: this.optionval.baseTowns
            },
            editable: true,
            autosize: true
          },

          {
            label: "停車場登記證號",
            name: "regNo",
            editable: true,
            autosize: true
          },
          {
            label: "停車場名稱",
            name: "nameZhTw",
            editable: true,
            autosize: true
          },
          {
            label: "停車場名稱(English)",
            name: "nameEnUs",
            editable: true,
            autosize: true
          },
          {
            label: "停車場簡稱",
            name: "shortNameZhTw",
            editable: true,
            autosize: true
          },
          {
            label: "停車場簡稱(English)",
            name: "shortNameEnUs",
            editable: true,
            autosize: true
          },
          {
            label: "停車場空間範圍",
            name: "geometry",
            editable: true,
            autosize: true,
            edittype: "number",
            formatter: "number"
          },
          {
            label: "停車場綜合描述",
            name: "description",
            editable: true,
            autosize: true
          },
          {
            label: "停車場連絡電話",
            name: "telephone",
            editable: true,
            autosize: true
          },
          {
            label: "緊急連絡電話",
            name: "emergencyPhone",
            editable: true,
            autosize: true
          },
          {
            label: "位置經度(WGS84)",
            name: "longitude",
            editable: true,
            autosize: true
          },
          {
            label: "位置緯度(WGS84)",
            name: "latitude",
            editable: true,
            autosize: true
          },
          {
            label: "電子信箱",
            name: "email",
            editable: true,
            autosize: true
          },
          {
            label: "停車場地址",
            name: "address",
            editable: true,
            autosize: true
          },
          {
            label: "官網網址",
            name: "webUrl",
            editable: true,
            autosize: true
          },
          {
            label: "票價資訊網址",
            name: "fareUrl",
            editable: true,
            autosize: true
          },
          {
            label: "票價資訊文字描述",
            name: "fareDescription",
            editable: true,
            autosize: true
          },
          {
            label: "優惠費率文字說明",
            name: "specialOfferDescription",
            editable: true,
            autosize: true
          },
          {
            label: "是否在營業時間外不收費",
            name: "isFreeParkingOutOfHours",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "車輛限制文字描述",
            name: "vehicleRestriction",
            editable: true,
            autosize: true
          },
          {
            label: "是否為公有停車場",
            name: "isPublic",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },

            autosize: true
          },
          {
            label: "是否有提供動態剩餘車位資訊",
            name: "liveOccuppancyAvailable",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有電動車充電設施",
            name: "evrechargingAvailable",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有提供月票服務",
            name: "monthlyTicketAvailable",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有提供季票服務",
            name: "seasonTicketAvailable",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有提供預約停車服務",
            name: "reservationAvailable",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "預約網址",
            name: "reservationUrl",
            editable: true,
            autosize: true
          },
          {
            label: "預約資訊文字描述",
            name: "reservationDescription",
            editable: true,
            autosize: true
          },
          {
            label: "是否有無障礙設施",
            name: "wheelchairAccessible",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否允許停車過夜",
            name: "overnightPermitted",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有自動售票機",
            name: "ticketMachine",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有廁所",
            name: "toilet",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有餐廳",
            name: "restaurant",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有加油站",
            name: "gasStation",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有商店",
            name: "shop",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有閘口",
            name: "gated",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有照明設施",
            name: "lighting",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否停車安全有保障",
            name: "secureParking",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有售票處",
            name: "ticketOffice",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否允許於停車場區域內裝卸危險物品",
            name: "prohibitedForAnyHazardousMaterialLoads",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有管理人員",
            name: "securityGuard",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "是否有監視系統",
            name: "supervision",
            editable: true,
            edittype: "select",
            formatter: "select",
            editoptions: {
              value: "true:是;false:否"
            },
            autosize: true
          },
          {
            label: "停車場附近的地標/地物",
            name: "landMark",
            editable: true,
            autosize: true
          },
          {
            label: "停車場所在大樓名稱",
            name: "buildingName",
            editable: true,
            autosize: true
          },
          {
            label: "停車場位置圖網址",
            name: "locationMapUrl",
            editable: true,
            autosize: true
          }
        ],
        rownumbers: true, // show row numbers
        shrinkToFit: false,
        loadonce: true,
        viewrecords: true,
        autowidth: true,
        height: "auto",
        rowNum: 10,
        rowList: [5, 20],

        onSelectRow: function(ids) {
          vm.pk = ids;
        },
        pager: "#jqGridPager"
      });
    }
  }
};
</script>
<style>
</style>
