<template>
  <article class="editable-table">
    <div class="this-inside-table">
      <slot name="title"></slot>
    </div>
    <!-- modal -->
    <b-modal id="popup-confirm" centered title="">
      <div class="my-4">Bạn có chắc muốn xoá bản ghi không?</div>
      <template #modal-footer>
        <div class="w-100 d-flex justify-content-between">
          <b-button
            variant="light"
            size="md"
            class="float-left"
            @click="show = false"
          >
            Không
          </b-button>
          <b-button
            variant="success"
            size="md"
            class="float-right"
            @click="show = false"
          >
            Có
          </b-button>
        </div>
      </template>
    </b-modal>
    <b-form-input
      class="w-25 mb-3"
      v-model="searchText"
      :placeholder="searchPlaceHolder"
      v-if="displayFilter"
    ></b-form-input>
    <!-- table -->
    <b-table
      class="b-table"
      :items="tableItems"
      :fields="tableFields"
      :striped="striped"
      :border="true"
      :hover="true"
      responsive="sm"
      table-variant="none"
      thead-tr-class="custom-th-row"
      :tbody-tr-class="setRowStyle"
      @row-clicked="onClickRow"
    >
      <template
        v-for="(field, index) in tableFields"
        #[`cell(${field.key})`]="data"
        v-show="data.isHide"
      >
        <div class="cell-container" :class="[field.class]">
          <!-- edit mode -->
          <div v-if="editMode == 1" class="content-padding">
            <div v-click-outside="clickOutSide">
              <b-form-datepicker
                v-if="
                  field.type === 'date' &&
                  tableItems[data.index].isEdit &&
                  edittingField == field.key
                "
                :key="index"
                :type="field.type"
                :value="tableItems[data.index][field.key]"
                @input="(value) => inputHandler(value, data.index, field.key)"
              ></b-form-datepicker>

              <!-- select -->
              <b-form-select
                v-if="
                  field.type === 'select' &&
                  tableItems[data.index].isEdit &&
                  edittingField == field.key
                "
                :key="index"
                :value="tableItems[data.index][field.key]"
                @input="(value) => inputHandler(value, data.index, field.key)"
                :options="field.options"
              ></b-form-select>

              <!-- input thông thường -->
              <div>
                <b-form-input
                  v-if="
                    (field.type == 'number' || field.type == 'text') &&
                    tableItems[data.index].isEdit &&
                    edittingField == field.key
                  "
                  :key="index"
                  :type="field.type"
                  :value="tableItems[data.index][field.key]"
                  @blur="
                    (e) => inputHandler(e.target.value, data.index, field.key)
                  "
                ></b-form-input>
              </div>
            </div>
          </div>
          <div
            v-if="field.type === '_tree'"
            v-show="tableItems[data.index].isParent"
            class="m-collapse m-tree-node"
            @click="toggleRow(data)"
          ></div>
          <!-- checkbox -->
          <b-checkbox
            v-if="field.type === 'checkBox'"
            :checked="tableItems[data.index].isSelected"
            size="md"
            :key="index"
            :disabled="editMode == 0"
            class="custom-checkbox"
            @change="selectRowHandler(data)"
          ></b-checkbox>
          <!-- actiongroup -->
          <div class="h-100 action-group" v-if="field.type === '_action'">
            <!-- <b-button @click="editRowHandler(data)">
              <span v-if="!tableItems[data.index].isEdit">Edit</span>
              <span v-else>Done</span>
            </b-button> -->
            <div
              v-b-modal.popup-confirm
              class="icon-delete"
              @click="removeRowHandler(data.index)"
            ></div>
          </div>

          <!-- display text -->
          <div
            class="cell-content content-padding cell-content-text"
            :key="index"
            v-on:click="handleEditCell(data.index, field.key)"
            v-if="
              (editMode == 0 ||
                !tableItems[data.index].isEdit ||
                edittingField != field.key) &&
              !['checkBox', '_action'].includes(field.type)
            "
          >
            {{ data.value }}
          </div>
        </div>
      </template>
    </b-table>
  </article>
</template>

<script>
import ClickOutside from "vue-click-outside";

export default {
  name: "EditableTable",
  components: {},
  props: {
    value: Array,
    fields: Array,
    editMode: Number,
    isTreeView: Boolean,
    searchPlaceHolder: String,
    displayFilter: Boolean,
    striped: {
      default: true,
      type: Boolean,
    },
  },
  data() {
    return {
      tableItems: this.value.map((item) => ({
        ...item,
        isEdit: false,
        isSelected: false,
      })),
      tableFields: this.fields.map((field) => ({
        ...field,
        tdClass: (field.tdClass || "") + " custom-td",
        thClass: "custom-th",
      })),
      openDialog: false,
      edittingField: "", // trường đang được sửa
      edittingRowIndex: null, //index Dòng đang được sửa
      searchText: "",
    };
  },
  methods: {
    editRowHandler(data) {
      this.tableItems[data.index].isEdit = !this.tableItems[data.index].isEdit;
    },
    inputHandler(value, index, key) {
      this.tableItems[index][key] = value;
      this.$set(this.tableItems, index, this.tableItems[index]);
      this.$emit("input", this.tableItems);
    },
    addRowHandler() {
      const newRow = this.tableFields.reduce(
        (a, c) => ({ ...a, [c.key]: null }),
        {}
      );
      newRow.isEdit = true;
      this.tableItems.unshift(newRow);
      this.$emit("input", this.tableItems);
    },
    removeRowHandler(index) {
      // this.tableItems = this.tableItems.filter((item, i) => i !== index);
      // this.$emit("input", this.tableItems);
    },
    removeRowsHandler() {
      this.tableItems = this.tableItems.filter((item) => !item.isSelected);
      this.$emit("input", this.tableItems);
    },
    selectRowHandler(data) {
      this.tableItems[data.index].isSelected =
        !this.tableItems[data.index].isSelected;
    },
    /**
     * Thực hiện sửa ô
     * index: ô cần sửa
     * editField: trường cần sửa
     */
    handleEditCell(index, editField) {
      this.edittingField = editField;
      if (this.edittingRowIndex || this.edittingRowIndex == 0) {
        this.tableItems[this.edittingRowIndex].isEdit = false;
      }
      this.tableItems[index].isEdit = true;
      this.edittingRowIndex = index;
    },
    /**
     * Click ngoài
     */
    clickOutSide() {
      this.edittingField = "";
    },
    /**
     * Thêm class cho dòng
     * @param {*} item
     */
    setRowStyle(item) {
      let treeClass = "";
      if (item) {
        treeClass += "row-" + item.id;
        if (this.isTreeView) {
          if (item.parentId) {
            if (item.isParent) {
              treeClass += " m-parent-row";
              this.rowGrade++;
            }
            treeClass += " m-child-row";
            treeClass += " parent-id-" + item.parentId;
            treeClass += " m-grade-" + this.rowGrade;
          } else {
            if (item.isParent) {
              treeClass += " m-parent-row m-grade-0";
              this.rowGrade = 1;
            }
          }
        }
      }
      return treeClass;
    },
    /**
     * Ẩn hiện dòng
     * @param {*} data
     */
    toggleRow(data) {
      let currentElement = document.getElementsByClassName(
        "row-" + data.item.id
      )[0];
      let toggleIcon = currentElement.getElementsByClassName("m-tree-node")[0];
      toggleIcon.classList.toggle("m-expand");
      let childrenList = this.getAllChild(data.item);
      childrenList.shift();
      childrenList.forEach((child) => {
        let childHtml = document.getElementsByClassName("row-" + child.id)[0];
        childHtml?.classList.toggle("d-none");
      });
    },
    /**
     * Lấy danh sách các dòng con
     * @param {*} row
     */
    getAllChild(row) {
      let listRow = [];
      listRow.push(row);
      if (row.isParent) {
        let children = this.tableItems.filter(
          (item) => item.parentId == row.id
        );
        for (let i = 0; i < children.length; ++i) {
          listRow = listRow.concat(this.getAllChild(children[i]));
        }
      }
      return listRow;
    },
    /**
     * sực kiện click row
     * @param {*} item
     * @param {*} index
     * @param {*} e
     */
    onClickRow(item, index, e) {
      this.$emit("on-click-row", item, index, e);
    },
  },
  mounted() {
    // prevent click outside event with popupItem.
    this.popupItem = this.$el;
  },

  // do not forget this section
  directives: {
    ClickOutside,
  },
};
</script>

<style lang="scss">
.editable-table {
  .action-container {
    margin-bottom: 10px;
    display: flex;
    justify-content: end;
  }
  .action-container button {
    margin-right: 5px;
  }
  .delete-button {
    margin-left: 5px;
  }

  .custom-th-row {
    border-bottom: 1px solid #dee2e6;
  }

  .custom-td,
  .custom-th {
    padding: 0;
    border-top: 1px solid #dee2e6;
    height: 35px;
    border-bottom: 0 !important;
    // border-left: 1px solid #dee2e6;
  }
  .custom-td {
    cursor: pointer;
    .cell-content-text {
      padding: 0 8px;
    }
    .action-group {
      display: flex;
      align-items: center;
      padding: 0 8px;
    }
  }
  .custom-th {
    font-weight: 700;
    color: #38393d;
    padding: 0 8px !important;
    div {
      height: 75%;
    }
  }
  .m-parent-row {
    font-weight: 600;
    .content-padding {
      // padding: 0;
    }
  }
  .content-padding {
    padding: 0;
  }

  .custom-checkbox {
    margin-left: 7px !important;
    margin-top: 5px;
    // display: flex;
    // justify-content: center;
    // align-items: center;
    input {
      // width: 15px;
      // height: 15px;
      display: none;
    }
  }
  .table > :not(:first-child) {
    border-top: 0 !important;
  }
  .table {
    border: 1px solid #dee2e6;
    .cell-container {
      height: 100%;
      .cell-content {
        height: 100%;
        display: flex;
        align-items: center;
      }
    }
  }
}
</style>
