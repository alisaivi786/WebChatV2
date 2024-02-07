<template>
  <div style="border: 1px solid #ccc">
    <Toolbar
      style="border-bottom: 1px solid #ccc"
      :editor="editorRef"
      :defaultConfig="toolbarConfig"
      :mode="mode"
    />
    <Editor
      style="height: 20vh; overflow-y: hidden"
      v-model="valueHtml"
      @input="handleValueChange"
      :defaultConfig="editorConfig"
      :mode="mode"
      @onCreated="handleCreated"
    />
  </div>
</template>

<script>
import "@wangeditor/editor/dist/css/style.css"; // import css

import { onBeforeUnmount, ref, shallowRef, onMounted } from "vue";
import { Editor, Toolbar } from "@wangeditor/editor-for-vue";

export default {
  components: { Editor, Toolbar },
  setup() {
    // editor instance, use `shallowRef`
    const editorRef = shallowRef();

    // content HTML
    const valueHtml = ref("");

    const handleValueChange = () => {
      //$emit("input", valueHtml.value);
    };

    // Simulate ajax async set HTML
    onMounted(() => {
      setTimeout(() => {
        //valueHtml.value = '<p>Ajax async set HTML.</p>'
      }, 1500);
    });

    var IMAGE_SVG =
      '<svg viewBox="0 0 1024 1024"><path d="M959.877 128l0.123 0.123v767.775l-0.123 0.122H64.102l-0.122-0.122V128.123l0.122-0.123h895.775zM960 64H64C28.795 64 0 92.795 0 128v768c0 35.205 28.795 64 64 64h896c35.205 0 64-28.795 64-64V128c0-35.205-28.795-64-64-64zM832 288.01c0 53.023-42.988 96.01-96.01 96.01s-96.01-42.987-96.01-96.01S682.967 192 735.99 192 832 234.988 832 288.01zM896 832H128V704l224.01-384 256 320h64l224.01-192z"></path></svg>';

    let toolbarConfig = {};
    toolbarConfig.toolbarKeys = [
      "headerSelect",
      "blockquote",
      "|",
      "bold",
      "underline",
      "italic",
      "through",
      "color",
      "bgColor",
      "|",
      "fontFamily",
      "|",
      "bulletedList",
      "numberedList",
      "|",
      "emotion",
      "insertLink",
      {
        key: "group-image",
        title: "editor.image",
        iconSvg: IMAGE_SVG,
        menuKeys: ["insertImage", "uploadImage"], // Include uploadImage
        uploadImage: {
          server: "https://localhost:5173/api/upload", // Your server endpoint for image upload
          fieldName: "image", // Field name used to send the image file
        },
      },
    ];
    const editorConfig = { placeholder: "Type here...", MENU_CONF: {} };

    editorConfig.MENU_CONF["uploadImage"] = {
      server: "https://localhost:5173/api/upload-image",
      fieldName: "upload-image",
      // other config...
    };

    // Timely destroy `editor` before vue component destroy.
    onBeforeUnmount(() => {
      const editor = editorRef.value;
      if (editor == null) return;
      editor.destroy();
    });

    const handleCreated = (editor) => {
      editorRef.value = editor;
      console.log(editor.getMenuConfig("uploadImage"));
    };

    return {
      editorRef,
      mode: "default", // or 'simple'
      valueHtml,
      handleValueChange,
      toolbarConfig,
      editorConfig,
      handleCreated,
    };
  },
};
</script>
